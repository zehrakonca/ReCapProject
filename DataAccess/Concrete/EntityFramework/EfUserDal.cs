using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfUserDal : EfEntityRepositoryBase<User, CarContext>, IUserDal
	{
		public List<OperationClaim> GetClaims(User user)
		{
            using (CarContext context = new CarContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.ID equals userOperationClaim.OperationClaimID
                             where userOperationClaim.UserID == user.UserID
                             select new OperationClaim
                             {

                                 ID = operationClaim.ID,
                                 Name = operationClaim.Name

                             };
                return result.ToList();

            }
        }
	}
}
