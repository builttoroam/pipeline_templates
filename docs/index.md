---
title: Build and Deployment Templates
description: Reusable templates for both build and deployment pipeline stages
author: Nick Randolph @ Built to Roam
---

# Build and Deployment Templates

Create a Service Connection to GitHub - [Instructions](https://docs.microsoft.com/en-us/azure/devops/pipelines/library/service-endpoints)  
(We'll call this github_connection but feel free to name this connection how you want)

Referencing the pipeline_templates repository as a resource. The endpoint parameter needs to match the name of the GitHub connection from the previous step. Give the repository a name, in this case all_templates, which will be used when referencing a template.

```YAML
resources:
  repositories:
    - repository: all_templates
      type: github
      name: builttoroam/pipeline_templates
      ref: refs/tags/v0.5.1
      endpoint: github_connection
```

Reference a template using the template argument. The following example references the deploy-appcenter.yml template that's in the azure/mobile folder in the repository named all_templates

```YAML
# App Center Deployment Template
# Template for distributing Android, iOS and Windows apps to testers via App Center
stages:
- template:  azure/mobile/deploy-appcenter.yml@all_templates
  parameters:
    artifact_folder: 
    ...
```

The templates in this repository are broken down into build and deploy templates as follows:

## Build 
[Xamarin Android](./build//XamarinAndroid.md)   
[Xamarin iOS](./build//XamariniOS.md)   
[Xamarin Windows (UWP)](./build//XamarinWindows.md)   

## Deploy

[AppCenter](./deploy//AppCenter.md)

