using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.MappingConfig;
using Application.Models;
using Application.Repository;
using AutoMapper;
using MediatR;
using Domain;
using System.Reflection.Metadata.Ecma335;
using Application.PipelineBehaviours.Contract;

namespace Application.Features.Images.Commands
{
    public class CreateImageRequest:IRequest<bool>,Ivalidatable
    {
        public NewImage NewImage { get; set; }
        public CreateImageRequest(NewImage newImage)
        {
            NewImage = newImage;

        }
    }
    public class CreateImageRequestHandler : IRequestHandler<CreateImageRequest, bool>
    {
        private readonly IImageRepo _imagerepo;
        private readonly IMapper _mapper;
        public CreateImageRequestHandler(IImageRepo imagerepo,IMapper mapper)
        {
            _imagerepo = imagerepo;
        _mapper = mapper;
        }

        public async Task<bool> Handle(CreateImageRequest request, CancellationToken cancellationToken)
        {
           Image image= _mapper.Map<Image>(request.NewImage);
            await _imagerepo.AddNewAsync(image);
            return true;

        }
       
    }
}
