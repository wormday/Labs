x=4
puts 'puts \'This appears to be false.\' unless x==4'
puts 'This appears to be false.' unless x==4

puts 'puts \'This appears to be false.\' if x==4'
puts 'This appears to be false.' if x==4

if x==4 
	puts '1'
end

x=x+1 while x<10
puts x

x=0
while x<10
	x=x+1
	puts x
end
puts x

if 1
	puts '1 evaluate to true.'
end

if 0
	puts '0 evaluate to true.'
end

if 'abc'
	puts 'abc evaluate to true.'
end

puts 'false evaluate to false' if false
puts 'nil evaluate to false' if nil

