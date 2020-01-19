using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.JaintorApp
{
    public class GetJaintors
    {
        public class Query : IRequest<List<Jaintor>>
        {

        }

        public class Handler : IRequestHandler<Query, List<Jaintor>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Jaintor>> Handle(Query request, CancellationToken cancellationToken)
            {
                var jaintors = await _context.Jaintors.ToListAsync();

                return jaintors;
            }
        }
    }
}
