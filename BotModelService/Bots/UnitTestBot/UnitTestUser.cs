using System;
using BotModel.Bots.BotTypes.Enums;
using BotModel.Bots.BotTypes.Interfaces.Messages;

namespace BotModel.Bots.UnitTestBot
{
    public class UnitTestUser : IUser
    {
    public string Display => "Тестовый пользователь";
    public Guid Id { get; set; } = new Guid("{4A7D6568-CBFE-42F7-90C9-D53F4EB4D116}");
    public TypeUser Type { get; set; } = TypeUser.Admin | TypeUser.Developer;
    }
}