using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnLineStore.Application.ViewModels;
using MediatR;

namespace OnLineStore.Application.Feature.User.Queries
{
   public class GetAllUsersQuery : IRequest<List<UserViewModel>>
    {

    }
}
