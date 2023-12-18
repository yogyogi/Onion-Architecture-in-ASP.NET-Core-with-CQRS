using MediatR;

namespace Application.CQRS.Commands
{
    public class UpdateStudentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Standard { get; set; }
        public int Rank { get; set; }
        public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, int>
        {
            private readonly IAppDbContext context;
            public UpdateStudentCommandHandler(IAppDbContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
            {
                var student = context.Students.Where(a => a.Id == command.Id).FirstOrDefault();

                if (student == null)
                    return default;

                student.Name = command.Name;
                student.Standard = command.Standard;
                student.Rank = command.Rank;
                await context.SaveChangesAsync();
                return student.Id;
            }
        }
    }
}
