﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignments.PersonDetails.Domain.Contracts
{
    public interface IValidationException
    {
        List<IErrorMessage> Invalid { get; set; }
    }
}
