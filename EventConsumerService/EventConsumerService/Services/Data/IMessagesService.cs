using System.Collections.Generic;
using EventConsumerService.Data.Entities;

namespace EventConsumerService.Services.Data
{
    public interface IMessagesService
    {
	    IEnumerable<MessageEntity> GetAllMessages();
	    MessageEntity InsertMessage(string message);
    }
}
