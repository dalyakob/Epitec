using DevTraining.Core.Models;
using System;

namespace DevTraining.Shared
{
    public interface IResponseDto
    {
        Contact GetById(Guid id);
    }
}