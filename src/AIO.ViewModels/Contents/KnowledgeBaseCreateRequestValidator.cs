using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIO.ViewModels.Contents
{
    public class KnowledgeBaseCreateRequestValidator : AbstractValidator<KnowledgeBaseCreateRequest>
    {
        public KnowledgeBaseCreateRequestValidator()
        {
        }
    }
}