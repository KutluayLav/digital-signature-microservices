using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignatureService.Contracts.Responses;

public class VerifyResponse
{
    public bool IsValid { get; set; }
}
