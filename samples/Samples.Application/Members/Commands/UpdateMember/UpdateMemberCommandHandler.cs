﻿//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using D20Tek.Patterns.Result;
using Samples.Core.Abstractions;
using Samples.Core.Entities;
using Samples.Core.Errors;

namespace Samples.Application.Members.Commands.UpdateMember;

public sealed class UpdateMemberCommandHandler
{
    private readonly IMemberRepository _memberRepository;

    public UpdateMemberCommandHandler(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task<Result<Member>> Handle(
        UpdateMemberCommand command,
        CancellationToken cancellationToken = default)
    {
        var existingMember = await _memberRepository.GetByIdAsync(command.Id, cancellationToken);
        if (existingMember is null)
        {
            return DomainErrors.Member.NotFound(command.Id);
        }

        var member = new Member(
            command.Id,
            command.FirstName,
            command.LastName,
            command.Email);

        await _memberRepository.UpdateAsync(member, cancellationToken);

        return member;
    }
}
