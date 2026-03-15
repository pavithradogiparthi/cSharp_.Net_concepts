using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
    public class GetAllRequest : IRequest<List<ImageDto>>,ICachable
    {
        public string CacheKey { get; set; }
        public bool BypassCache { get; set; }
        public TimeSpan SlidingExpiration { get; set; }
        public GetAllRequest()
        {
            CacheKey = "GetImageRequest";
        }


    }
    public class GetAllRequestHandler : IRequestHandler<GetAllRequest, List<ImageDto>>
    {
        private readonly IImageRepo _imageRepo;
        private readonly IMapper _mapper;
        public GetAllRequestHandler(IImageRepo imageRepo,IMapper mapper)
        {
            _imageRepo = imageRepo;
            _mapper = mapper;
        }
        public async Task<List<ImageDto>> Handle(GetAllRequest request, CancellationToken cancellationToken)
        {
            List<Image> images = await _imageRepo.GetAllAsync();
            if(images!=null)
            {
                List<ImageDto> result = _mapper.Map<List<ImageDto>>(images);
                return result;
            }
            return null;
        }
       
    }
}
