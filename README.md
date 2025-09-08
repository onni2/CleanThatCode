# CleanThatCode
A small assingment for Web developement in HR

how to use doecker file

run 
docker build -t cleanthatcode-tests -f Dockerfile.test .
then
docker run --rm cleanthatcode-tests
it should come out with something like

"Passed!  - Failed:     0, Passed:    11, Skipped:     0, Total:    11, Duration: 83 ms - CleanThatCode.Community.Tests.dll (net8.0)"
