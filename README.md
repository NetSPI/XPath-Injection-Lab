# XPath-Injection-Lab
git clone https://github.com/NetSPI/XPath-Injection-Lab.git
cd XPath-Injection-Lab
docker build -t bookapp . 
docker run -p 8888:80 bookapp
