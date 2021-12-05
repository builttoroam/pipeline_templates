---
title: Build and Deployment Templates
description: Reusable templates for both build and deployment pipeline stages
author: Nick Randolph @ Built to Roam
---

# Build and Deployment Templates

The Pipeline Templates repository was setup to help reduce the complexity associated with creating build and deployment pipelines for Azure DevOps. The aim is to have a series of templates that pipeline developers can pick and choose from. 

This is an open source project, so feel free to reference or copy the templates. If you find the templates useful, please let us know, particularly if there are features you'd like to see or even other templates. Lastly, we're always open to community contributions, so if you'd like to contribute, feel free to raise a PR or two.

# Getting Started

In order to reference the template, you first need to create a Service Connection to GitHub - [Instructions](https://docs.microsoft.com/en-us/azure/devops/pipelines/library/service-endpoints)  
(We'll call this github_connection but feel free to name this connection how you want)

Next, you need to setup a reference the pipeline_templates repository as a resource. The endpoint parameter needs to match the name of the GitHub connection from the previous step. Give the repository a name, in this case all_templates, which will be used when referencing a template.

```yaml
resources:
  repositories:
    - repository: all_templates
      type: github
      name: builttoroam/pipeline_templates
      ref: refs/tags/v0.5.1
      endpoint: github_connection
```

Lastly, you just reference a template using the template argument. The following example references the deploy-appcenter.yml template that's in the azure/mobile folder in the repository named all_templates

```yaml
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

The following are all stageList templates

[Xamarin Android](./build//XamarinAndroid.md)   
[Xamarin iOS](./build//XamariniOS.md)   
[Xamarin Windows (UWP)](./build//XamarinWindows.md)   

## Deploy

The following are all stageList templates

[AppCenter](./deploy//AppCenter.md)

## Components

The following are all stepList templates

[NuGet Install and Restore](./steps//nuget-install-and-restore.md)
