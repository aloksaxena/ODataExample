using Coles.PoC.Infra.EFCore;
using Coles.PoC.Infra.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Coles.PoC.Infra.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
	protected RepositoryContext RepositoryContext;

	/// <summary>
	/// RepositoryBase
	/// </summary>
	/// <param name="repositoryContext">RepositoryContext</param>
	public RepositoryBase(RepositoryContext repositoryContext)
	{
		RepositoryContext = repositoryContext;
	}
	/*
	Cannot access a disposed context instance. 
	A common cause of this error is disposing a context instance that was resolved from 
	dependency injection and then later trying to use the same context instance elsewhere 
	in your application. This may occur if you are calling 'Dispose' on the context instance, 
	or wrapping it in a using statement. If you are using dependency injection, you should let the 
	dependency injection container take care of disposing context instances.
	Object name: 'RepositoryContext'.
	 * */
	/// <summary>
	/// FindAll
	/// </summary>
	/// <param name="trackChanges">bool</param>
	/// <returns>IQueryable<T></returns>
	public IQueryable<T> FindAll(bool trackChanges)
	{
		try
		{
			bool v = !trackChanges;
			return v ? RepositoryContext.Set<T>().AsNoTracking() : RepositoryContext.Set<T>();
		}
		catch (Exception ex)
		{

			bool s = false;

		}
		return RepositoryContext.Set<T>();
	}

	/// <summary>
	/// FindByCondition
	/// </summary>
	/// <param name="expression">Expression<Func<T, bool>></param>
	/// <param name="trackChanges">bool</param>
	/// <returns>IQueryable<T></returns>
	public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) => !trackChanges ?
		  RepositoryContext.Set<T>()
			.Where(expression)
			.AsNoTracking() :
		  RepositoryContext.Set<T>()
			.Where(expression);

	/// <summary>
	/// Create
	/// </summary>
	/// <param name="entity">T</param>
	public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);

	/// <summary>
	/// Update
	/// </summary>
	/// <param name="entity">T</param>
	public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);

	/// <summary>
	/// Delete
	/// </summary>
	/// <param name="entity">T</param>
	public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);

	/// <summary>
	/// Update range
	/// </summary>
	/// <param name="entityList"></param>
	public void UpdateRange(IList<T> entityList) => RepositoryContext.Set<T>().UpdateRange(entityList);
}