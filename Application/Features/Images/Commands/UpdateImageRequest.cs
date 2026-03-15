using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Application.Repository;
using MediatR;
using Domain;
using Application.PipelineBehaviours.Contract;


namespace Application.Features.Images.Commands
{
    public class UpdateImageRequest : IRequest<bool>,Ivalidatable,ICacheRemoval
    {
        public UpdateImage UpdateImage { get; set; }
      
        public List<string> CacheKeys { get; set; }
      
        public UpdateImageRequest(UpdateImage updateimage)
        {
            UpdateImage = updateimage;
            CacheKeys = new() { $"GetImagebyIdRequest: {UpdateImage.Id}" , "GetImageRequest" };
        }
    }
    public class UpdateImageRequestHandler : IRequestHandler<UpdateImageRequest, bool>
    {

        private readonly IImageRepo _imageRepo;
        public UpdateImageRequestHandler(IImageRepo imageRepo)
        {
            _imageRepo = imageRepo;
        }

        public async Task<bool> Handle(UpdateImageRequest request, CancellationToken cancellationToken)
        {
            Image imageindb = await _imageRepo.GetByIdAsync(request.UpdateImage.Id);
            if (imageindb != null)
            {
                imageindb.Name = request.UpdateImage.Name;
                imageindb.Path = request.UpdateImage.Path;
                await _imageRepo.UpdateAsync(imageindb);
                return true;
            }
            return false;
        }
    }
}
