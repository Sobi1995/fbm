using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Setting;
public class JwtSettings
{
    public string AccessTokenSecret { get; set; } = default!;
    public string RefreshTokenSecret { get; set; } =default!;
    public double AccessTokenExpirationMinutes { get; set; }
    public double RefreshTokenExpirationMinutes { get; set; }
    public string Issuer { get; set; } =default!;
    public string Audience { get; set; }= default!;
}