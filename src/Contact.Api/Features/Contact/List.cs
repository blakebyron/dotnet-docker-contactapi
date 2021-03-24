using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contact.Infrastructure.Data;
using MediatR;

namespace Contact.Api.Features.Contact
{
    public class List
    {

        public class Query : IRequest<Result>
        {
        }

        public class Result
        {

            public IEnumerable<Contact> Items { get; set; }

            public class Contact
            {
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Organisation { get; set; }
            }

            public Result()
            {
                this.Items = new List<Contact>();
            }
        }

        public class QueryHandler : IRequestHandler<Query, Result>
        {
            private readonly ContactDbContext context;

            public QueryHandler(ContactDbContext context)
            {
                this.context = context;
            }
            public Task<Result> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = new Result();
                result.Items = this.context.Contacts.Select(f=> new Result.Contact() { FirstName =f.FirstName, LastName = f.LastName, Organisation = f.Organisation }).ToList();
                return Task.FromResult<Result>(result);
            }
        }
    }
}
