using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Application.PipelineBehaviours.Contract;
using Application.Repository;
using Domain;
using MediatR;

namespace Application.Features.Images.Commands
{
    public class DeleteImageRequest:IRequest<bool>,ICacheRemoval
    {
        public int ImageId { get; set; }
        public List<string> CacheKeys { get ; set; }

        public DeleteImageRequest(int imageid)
        {
            ImageId = imageid;
            CacheKeys= new() { $"GetImagebyIdRequest", $"GetImagebyIdRequest:{ ImageId}" };
        }
    
    }
    public class DeleteImageRequestHandler : IRequestHandler<DeleteImageRequest, bool>
    {
        private readonly IImageRepo _imageRepo;
        public DeleteImageRequestHandler(IImageRepo imagerepo)
        {
            _imageRepo = imagerepo;
        }

        public async Task<bool> Handle(DeleteImageRequest request, CancellationToken cancellationToken)
        {

         Image Imageindb=await _imageRepo.GetByIdAsync(request.ImageId);
            if (Imageindb != null)
            {
                await _imageRepo.DeleteAsync(Imageindb);
                return true;
            }
            return false;
        }
    }
}
