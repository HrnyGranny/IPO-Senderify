using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSenderismo.Dominio
{
    public class Usuario
	{
		private String login;
		private String pass;

		public Usuario(String l, String p)
		{
			this.login = l;
			this.pass = p;
		}

		public String GetLogin() { return login; }
		public String GetPass() { return pass; }
	}
}
