using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities;
public class RefreshToken : BaseAuditableEntity
{
    public RefreshToken(Guid userId, string token)
    {
        UserId = userId;
        Token = token;
        
    }
   
 
    public Guid UserId { get; set; }
    public string Token { get; set; }
}