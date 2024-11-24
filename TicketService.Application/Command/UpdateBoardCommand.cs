using AutoMapper;
using MediatR;
using TicketService.Application.Dto;
using TicketService.Domain.Abstraction;

namespace TicketService.Application.Command;

public class UpdateBoardCommand : IRequest<bool>
{
    public required UpdateBoardDto Dto { get; set; }
}

public class UpdateBoardCommandHandler : IRequestHandler<UpdateBoardCommand, bool>
{
    private readonly IBoardRepository _repository;

    public UpdateBoardCommandHandler(IBoardRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<bool> Handle(UpdateBoardCommand request, CancellationToken cancellationToken)
    {
        var model = await _repository.GetByIdAsync(request.Dto.Id);

        if (model == null) return false;
        
        model.UpdateDateTime = DateTime.UtcNow;
        model.Name = request.Dto.Name;
        model.Title = request.Dto.Title;
            
        await _repository.UpdateAsync(model);

        _repository.SaveChanges();
        
        return true;
    }
}