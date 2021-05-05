---
title: Windows (UWP) Build Template
description: Template for building a Windows (UWP) application
author: Nick Randolph
---

# Windows (UWP) Build Template

Use this template to build Windows (UWP) applications from a Visual Studio Solution file.

## YAML snippet

```yaml
# Windows (UWP) Build Template
# Template for building a Windows (UWP) application
stages:
- template:  azure/mobile/build-xamarin-windows.yml@builttoroam_templates
  parameters:
    solution_filename:
    windows_cert_securefiles_filename:
    #stage_name:  # Optional 
    #depends_on:  # Optional 
    #build_windows_enabled:  # Optional 
    #build_number:  # Optional 
    #full_version_number:  # Optional 
    #solution_build_configuration:  # Optional 
    #solution_target_platform:  # Optional
    #uwpPackagePlatforms:  # Optional
    #windows_package_manifest_filename:  # Optional 
    #windows_cert_password:  # Optional 
    #artifact_name:  # Optional 
    #artifact_folder:  # Optional
    #application_package:  # Optional 
    #windows_upload_name:  # Optional 
    #onStart:  # Optional 
    #preBuild:  # Optional
    #postBuild:  # Optional 
    #prePublish:  # Optional
    #onEnd:  # Optional 
    #windows_nuget_version:  # Optional 

```


## Arguments

<table><thead><tr><th>Argument</th><th>Description</th></tr></thead>

<tr><td>stage_name</td><td>(Optional) The name of the stage, so that it can be referenced elsewhere (eg for dependsOn property). Defaults to 'Build_Windows'</td></tr>
<tr><td>depends_on</td><td>(Optional) The array of stages that this stage depends on. Default is that this stage does not depend on any other stage</td></tr>
<tr><td>build_windows_enabled</td><td>(Optional) Whether this stages should be executed. Note that setting this to false won't completely cancel the stage, it will merely skip most of the stages. The stage will appear to complete successfully, so any stages that depend on this stage will attempt to execute</td></tr>
<tr><td>build_number</td><td>(Optional) The build number to be applied to the application. Defaults to Build.BuildId built in variable</td></tr>
<tr><td>full_version_number</td><td>(Optional) The full application version number. Defaults to 1.0.XXX where XXX is the same as the build_number</td></tr>
<tr><td>solution_filename</td><td>(Required) The relative path to the solution file that should be built</td></tr>
<tr><td>solution_build_configuration</td><td>(Optional) The build configuration within the solution that should be invoked. Default is Release but can be overwritten if you want to do say a Debug build</td></tr>
<tr><td>solution_target_platform</td><td>(Optional) The target platform that the solution build will use. Defaults to 'x86'</td></tr>
<tr><td>uwpPackagePlatforms</td><td>(Optional) The platforms the the application package will include. Defaults to 'x86|x64|ARM'</td></tr>
<tr><td>windows_package_manifest_filename</td><td>(Optional) The relative path to the package.appxmanifest file that defines the application manifest. If not specified, template will search for package.appxmanifest file</td></tr>
<tr><td>windows_cert_securefiles_filename</td><td>(Required) The certificate file used to sign the application. This is the name of the certificate in Secure Files</td></tr>
<tr><td>windows_cert_password</td><td>(Optional) The password to unlock the certificate so it can be used. This is required if the certificate has a password set</td></tr>
<tr><td>artifact_name</td><td>(Optional) The name of the artifact to copy application to</td></tr>
<tr><td>artifact_folder</td><td>(Optional) The name of the folder to copy application to in the artifact</td></tr>
<tr><td>application_package</td><td>(Optional) The name of the application package to output</td></tr>
<tr><td>windows_upload_name</td><td>(Optional) The name of the upload package that can be submitted to the Microsoft Store</td></tr>
<tr><td>onStart</td><td>(Optional) Steps to be executed before stage starts</td></tr>
<tr><td>preBuild</td><td>(Optional) Steps to be executed before the build starts</td></tr>
<tr><td>postBuild</td><td>(Optional) Steps to be executed after the build has been invoked</td></tr>
<tr><td>prePublish</td><td>(Optional) Steps to be executed before application package is published to artifact</td></tr>
<tr><td>onEnd</td><td>(Optional) Steps to be executed at the end of the stage</td></tr>

<tr><td>windows_nuget_version</td><td>(Optional) Use to override the NuGet version (defaults to 5.6.0)</td></tr>


</table>

## Open source

This template is open source [on GitHub](https://github.com/builttoroam/pipeline_templates). Feedback and contributions are welcome.
