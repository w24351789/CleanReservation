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
    public class EditJaintor
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var jaintor = await _context.Jaintors.FindAsync(request.Id);
                if (jaintor == null)
                    throw new Exception("Jaintor not found");
                jaintor.FirstName = request.FirstName ?? jaintor.FirstName;
                jaintor.LastName = request.LastName ?? jaintor.LastName;


                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving change");
            }
        }
    }
}
