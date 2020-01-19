using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.JaintorApp
{
    public class GetJaintor
    {
        public class Query : IRequest<Jaintor>
        {
            public Guid JaintorId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Jaintor>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Jaintor> Handle(Query request, CancellationToken cancellationToken)
            {
                var jaintor = await _context.Jaintors.FindAsync(request.JaintorId);

                if (jaintor == null) throw new Exception("Not found");

                return jaintor;
            }
        }
    }
}
