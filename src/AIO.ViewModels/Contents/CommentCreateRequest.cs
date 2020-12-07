using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.Contents
{
    public class CommentCreateRequest
    {
        public string Content { get; set; }

        public int KnowledgeBaseId { get; set; }
    }
}