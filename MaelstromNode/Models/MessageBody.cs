﻿using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MaelstromNode.Models;

internal class MessageBody
{
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("msg_id")]
    public int? MsgId { get; set; }

    [JsonPropertyName("in_reply_to")]
    public int? InReplyTo { get; set; }

    private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
    };

    public string? Serialize()
    {
        return JsonSerializer.Serialize<object>(this, _jsonSerializerOptions);
    }
}
