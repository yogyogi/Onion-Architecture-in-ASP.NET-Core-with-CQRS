using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Commands
{
    public class DeleteStudentByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteStudentByIdCommandHandler : IRequestHandler<DeleteStudentByIdCommand, int>
        {
            private readonly IAppDbContext context;
            public DeleteStudentByIdCommandHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(DeleteStudentByIdCommand command, CancellationToken cancellationToken)
            {
                var student = await context.Students.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (student == null) return default;
                context.Students.Remove(student);
                await context.SaveChangesAsync();
                return student.Id;
            }
        }
    }
}
