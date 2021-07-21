using MemberRegistration.Business.Abstract;
using MemberRegistration.Business.DependencyResolvers.Ninject;
using MemberRegistration.Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var memberService = InstanceFactory.GetInstance<IMemberService>();
            memberService.Add(new Member { FirstName = "", LastName = "", DateOfBirth = new DateTime(),TcNo="",Email=" "});
            Console.WriteLine("Eklendi!");
            Console.ReadLine();
        }
    }
}
