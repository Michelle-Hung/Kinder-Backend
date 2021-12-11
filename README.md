# Kinder-Backend
[![Coverage Status](https://coveralls.io/repos/github/Michelle-Hung/Kinder-Backend/badge.svg?branch=main)](https://coveralls.io/github/Michelle-Hung/Kinder-Backend?branch=main)
### How to migrate .net5 to .net6 in the project
1. Download .net6 SDK
2. Modify all version from v5.x.x to v6.0.0 in .csproj file
3. Build project and test
4. Modify docker file from v5.x.x to v6.0.0
5. Build project with `docker build` and run project with `doker run` for verifying
### How to create GitHub Actions in project
1. Click Actions tab in your project
2. Choose an action that you need
3. Do some modifying(ex. project name, folder name, etc.)
4. Push
### How to implement code coverage in your project and display in README
Reference: https://samlearnsazure.blog/2021/01/05/code-coverage-in-github-with-net-core/
1. Download coverlet package in your project `coverlet.msbuild` and `coverlet.collect` NuGet package
2. Register in `Coverall` with GitHub account and link your repo that you want to implement code coverage
3. Add a step for generate coverage report in yaml file
4. Push code and yaml
5. Login `Coverall` and get Badage source code for README them copy it
6. Past the code to README in your project
