using System;
using System.IO;
using System.Net.Sockets;


namespace MKClickTool
{
	class MainClass
	{
		public static void Main(string[] args)
		{

			Console.WriteLine("===ATUALIZAÇÃO EM MASSA MIKROTIK - Developer By Lairon Costa===");
			Console.WriteLine("Digite a classe de ip (/24): ");
			string ip = Console.ReadLine();
			Console.WriteLine("Digite o usuário: ");
			string usuario = Console.ReadLine();
			Console.WriteLine("Digite a senha: ");
			string senha = Console.ReadLine();

			MK mikrotik = new MK(ip);

			if (mikrotik.Login(usuario, senha))
			{
				mikrotik.Send("/ip/address/add");
				mikrotik.Send("=address=192.168.0.1/24");
				mikrotik.Send("=interface=ether2");
				mikrotik.Send(".tag=ip", true);

				foreach (string h in mikrotik.Read())
				{
					Console.WriteLine(h);
					Console.ReadKey();
				}
			}
			else {
				Console.WriteLine("Nao Foi Possivel Fazer Login! - Usuario ou Senha Incorreta");
				mikrotik.Close();
			}

		}
	}
}
