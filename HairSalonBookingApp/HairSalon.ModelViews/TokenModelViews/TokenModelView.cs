using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.ModelViews.TokenModelViews
{
    public class TokenModelView
    {
        public string? AccessToken {  get; set; }
        public string? RefreshToken { get; set; }
    }
}
