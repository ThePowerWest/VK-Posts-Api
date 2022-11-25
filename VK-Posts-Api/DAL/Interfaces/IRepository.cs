using Ardalis.Specification;

namespace VK_Posts_Api.DAL.Interfaces;

/// <summary>
/// Интерфейс репозитория с CRUD методами
/// </summary>
public interface IRepository<T> : IRepositoryBase<T> where T : class
{ }