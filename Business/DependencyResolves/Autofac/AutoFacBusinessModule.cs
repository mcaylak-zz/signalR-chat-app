using Autofac;
using Business.Abstract.Chat;
using Business.Concrete.Chat;
using Core.Utilities.Security.jwt;
using DataAccessLayer.Abstract.ChatDal;
using DataAccessLayer.Concrete.EntityFramework.ChatDal;

namespace Business.DependencyResolves.Autofac
{
    // Dependency Injection olayının önüne geçmek için bu yapıyı kullanıyoruz.
    public class AutoFacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<ChatManager>().As<IChatService>();
            builder.RegisterType<EfMessageDal>().As<IMessageDal>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        }
    }
}
