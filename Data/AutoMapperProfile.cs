using AutoMapper;
using TodoListSPA.Entities;
using TodoListSPA.Entities.DTO;

namespace TodoListSPA.Data;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AddTodo, Todo>();
        CreateMap<UpdateTodo, Todo>();
    }
}
