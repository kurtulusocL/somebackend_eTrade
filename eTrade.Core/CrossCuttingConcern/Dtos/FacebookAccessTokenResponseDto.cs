﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eTrade.Core.CrossCuttingConcern.Dtos
{
    public class FacebookAccessTokenResponseDto
    {
        [JsonPropertyName("access-token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }
    }
}
