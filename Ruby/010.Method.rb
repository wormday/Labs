class A
	@s=1
	def self.s
		@s
	end
	def self.s=(value)
		@s=value
	end
	
	def s
	@s	
end

def s=(value)
@s=value
end

	
	attr :a,true
	def b
		@b
	end
	def bb=(value)
		@b=value
	end
	
	def c
		@c
	end
	
	def cc
	puts "cc="
	end
	
end
b=A.new
b.a = 3
puts b.a #3 虽然方法是a=,但是经过语法糖处理 =前可以有空格

b.bb= (4)
puts b.b; #4

A.s="333";
puts A.s #333

b.s="3333333"
puts b.s #333333  在类中声明的实例变量跟在方法中声明的实例变量 根本就是两个变量

puts A.s #333