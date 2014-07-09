using NSubstitute;
using TeamBot.Features.Snowman;
using TeamBot.Infrastructure.Slack.Models;
using TeamBot.Tests.Specifications;

namespace TeamBot.Tests.Features.Snowman
{
    public class Scenarios : HandlerScenarioBase<SnowmanHandler>
    {
        public override string Request
        {
            get { return "do you want to build a snowman?"; }
        }

        [Then]
        public override void ShouldRespondCorrectly()
        {
            Subject.Slack.Received().SendAsync(IncomingMessage.ReplyTo(), ":snowman:");
        }
    }
}