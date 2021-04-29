﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interface.IEvents
{
    public interface IEventBase : IMessage, INotification 
    {
    }
}