using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Queries
{
    public class GetAllStudentQuery : IRequest<IEnumerable<Student>>
    {

        public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentQuery, IEnumerable<Student>>
        {
            private readonly IAppDbContext context;
            public GetAllStudentQueryHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<Student>> Handle(GetAllStudentQuery query, CancellationToken cancellationToken)
            {
                var studentList = await context.Students.ToListAsync();
                if (studentList == null)
                {
                    return null;
                }
                return studentList.AsReadOnly();
            }
        }
    }
}
