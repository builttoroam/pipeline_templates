---
title: NuGet Install and Solution Restore Template
description: Template for installing NuGet and restoring packages for a Visual Studio solution
author: Nick Randolph
---

# NuGet Install and Solution Restore Template

Use this template to install a specific version of NuGet and restore packages for a Visual Studio solution file.

## YAML snippet

```yaml
# NuGet Install and Solution Restore Template
# Template for installing NuGet and restoring packages for a Visual Studio solution
stages:
- template:  azure/steps/nuget-install-and-restore.yml@builttoroam_templates
  parameters:
    solution_filename:
    #nuget_version_to_install: # Optional
```


## Arguments

<table><thead><tr><th>Argument</th><th>Description</th></tr></thead>
<tr><td>nuget_version_to_install</td><td>(Optional) Use to override the NuGet version (defaults to 4.4.1)</td></tr>
<tr><td>solution_filename</td><td>The relative path to the solution file that should be built</td></tr>


</table>

## Open source

This template is open source [on GitHub](https://github.com/builttoroam/pipeline_templates). Feedback and contributions are welcome.
