﻿using System.Linq.Expressions;

namespace Coles.PoC.Infra.Repositories.Contracts;

public interface IRepositoryBase<T>
{
	/// <summary>
	/// FindAll
	/// </summary>
	/// <param name="trackChanges">bool</param>
	/// <returns>IQueryable<T></returns>
	IQueryable<T> FindAll(bool trackChanges);

	/// <summary>
	/// FindByCondition
	/// </summary>
	/// <param name="expression">Expression<Func<T, bool>></param>
	/// <param name="trackChanges">bool</param>
	/// <returns>IQueryable<T></returns>
	IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);

	/// <summary>
	/// Create
	/// </summary>
	/// <param name="entity">T</param>
	void Create(T entity);

	/// <summary>
	/// Update
	/// </summary>
	/// <param name="entity">T</param>
	void Update(T entity);

	/// <summary>
	/// Delete
	/// </summary>
	/// <param name="entity">T</param>
	void Delete(T entity);
	/// <summary>
	/// Update range
	/// </summary>
	/// <param name="entityList"></param>
	void UpdateRange(IList<T> entityList);
}