﻿using GwiNews.Application.CQRS.UsersCQRS.Queries;
using GwiNews.Domain.Entities;
using MediatR;

namespace GwiNews.Application.CQRS.UserWithNewsCQRS.Queries
{
    public class GetUsersWithNewsQuery : GetUsersQuery, IRequest<IEnumerable<UserWithNews>>
    {
    }
}
