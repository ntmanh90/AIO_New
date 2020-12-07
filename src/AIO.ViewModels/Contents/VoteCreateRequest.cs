using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.Contents
{
    public class VoteCreateRequest
    {
        public int KnowledgeBaseId { get; set; }
        public string UserId { get; set; }
    }
}