p=proc do |value|
  puts value
  end
p2=proc {|value|
  puts value
  }
p3=proc {
  puts "dddddd"  
}
p.call(3)
p2.call(4)
p3.call
p.call
def d(a,b)
puts "---------"
yield
end
d(1,2) do puts "444444" end
def c(a,b,&d)
 puts "55555555555555555"
 puts a
 puts b
 puts d
 end
c(1,2)
