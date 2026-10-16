using KooliProjekt.Application.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace KooliProjekt.Application.Features.Cars
{
    public class GetCarsQuery : IRequest<Car>
    {
        public int Id { get; set; }
    }
}
