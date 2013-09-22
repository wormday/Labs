require 'highline'
hl=HighLine.new
a=lambda{|s| s.split(',')}
friends=hl.ask('Friends1:',a)

puts "#{friends}"

friends=hl.ask('Friends2'){|s| puts s.class}
