using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TeamBot.Infrastructure.Messages;
using TeamBot.Infrastructure.Slack;
using TeamBot.Infrastructure.Slack.Models;

namespace TeamBot.Features.Snowman
{
    public class SnowmanHandler : SlackMessageHandler
    {
        public SnowmanHandler(ISlackClient slack) : base(slack)
        {
        }

        public override string Help()
        {
            return "do you want to build a snowman?";
        }

        public override async Task Handle(IncomingMessage incomingMessage)
        {
            if (incomingMessage == null)
                throw new ArgumentNullException("incomingMessage");

            const string pattern = @"do you want to build a snowman\?*$";
            const string snowman = ":snowman:";

            if (Regex.IsMatch(incomingMessage.Text, pattern))
                await Slack.SendAsync(incomingMessage.ReplyTo(), snowman);
        }
    }
}