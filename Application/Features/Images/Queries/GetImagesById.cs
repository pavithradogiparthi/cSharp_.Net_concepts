using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Application.Repository;
using AutoMapper;
using MediatR;
using Domain;
using Application.PipelineBehaviours.Contract;

namespace Application.Features.Images.Queries
{
   public class GetImageById:IRequest<ImageDto>,ICachable
    {
        public int ImageId { get; set; }
        public string CacheKey { get; set; }
        public bool BypassCache { get;set; }
        public TimeSpan SlidingExpiration { get; set; }

        public GetImageById(int imageid)
        {
            ImageId = imageid;
            CacheKey = $"GetImagebyIdRequest:{ImageId}";
        }
    }
    public class GetImageByIdHandler : IRequestHandler<GetImageById, ImageDto>
    {
        private readonly IImageRepo _imagerepo;
        private readonly IMapper _mapper;
        public GetImageByIdHandler(IImageRepo imagerepo, IMapper mapper)
        {
            _imagerepo = imagerepo;
            _mapper = mapper;
        }
        public async Task<ImageDto> Handle(GetImageById request, CancellationToken cancellationToken)
        {
          Image imageindb=  await _imagerepo.GetByIdAsync(request.ImageId);
            if (imageindb != null)
            {
                ImageDto imagedto=_mapper.Map<ImageDto>(imageindb);
                return imagedto;
            }
            return null;
        }
    }

}
