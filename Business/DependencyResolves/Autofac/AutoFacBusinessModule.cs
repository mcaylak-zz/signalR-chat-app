using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using Core.Utilities.Security.jwt;

namespace Business.DependencyResolves.Autofac
{
    // Dependency Injection olayının önüne geçmek için bu yapıyı kullanıyoruz.
    public class AutoFacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Concrete.Chat.UserManager>().As<Abstract.Chat.IUserService>();
            builder.RegisterType<DataAccessLayer.Concrete.EntityFramework.ChatDal.EfUserDal>().As<DataAccessLayer.Abstract.ChatDal.IUserDal>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        }
    }
}
