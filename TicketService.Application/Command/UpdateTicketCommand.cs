using AutoMapper;
using MediatR;
using TicketService.Application.Dto;
using TicketService.Domain.Abstraction;

namespace TicketService.Application.Command;

public class UpdateTicketCommand : IRequest<bool>
{
    public required UpdateTicketDto Dto { get; set; }
}

public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand, bool>
{
    private readonly ITicketRepository _repository;

    public UpdateTicketCommandHandler(ITicketRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<bool> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
    {
        var model = await _repository.GetByIdAsync(request.Dto.Id);

        if (model == null) return false;
        
        model.UpdateDateTime = DateTime.UtcNow;
        model.Name = request.Dto.Name;
        model.Title = request.Dto.Title;
        model.Description = request.Dto.Description;
            
        await _repository.UpdateAsync(model);

        _repository.SaveChanges();
        
        return true;
    }
}