// <copyright file="TestSampler.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using System;
using OpenTelemetry.Trace;

namespace OpenTelemetry.Tests;

internal class TestSampler : Sampler
{
    public Func<SamplingParameters, SamplingResult> SamplingAction { get; set; }

    public SamplingParameters LatestSamplingParameters { get; private set; }

    public override SamplingResult ShouldSample(in SamplingParameters samplingParameters)
    {
        this.LatestSamplingParameters = samplingParameters;
        return this.SamplingAction?.Invoke(samplingParameters) ?? new SamplingResult(SamplingDecision.RecordAndSample);
    }
}
