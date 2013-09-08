require 'open-uri'
open('http://railscasts.com/episodes/archive') do |f|
  s=""
  puts f.readlines
  f.each do |line|
    s<<line
end
end