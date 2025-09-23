// GetuserByIDQuery
using MediatR;
using OnLineStore.Application.ViewModels;

public class GetuserByIDQuery : IRequest<UserViewModel>
{
    public string Id { get; set; }
    public GetuserByIDQuery(string id) { Id = id; }
}
